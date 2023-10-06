﻿using Microsoft.EntityFrameworkCore;
using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.VoucherRequest;
using TT_LTS_EDU.Handle.Response;
using TT_LTS_EDU.Helpers;
using TT_LTS_EDU.Services.Interface;

namespace TT_LTS_EDU.Services.Implement
{
    public class VoucherService : BaseService, IVoucherService
    {
        private readonly ResponseObject<VoucherDTO> _response;
        private readonly TokenHelper _tokenHelper;

        public VoucherService(ResponseObject<VoucherDTO> response, TokenHelper tokenHelper)
        {
            _response = response;
            _tokenHelper = tokenHelper;

        }

        public async Task<ResponseObject<VoucherDTO>> CheckVoucer(string code, int amount)
        {
            try
            {
                _tokenHelper.IsToken();
                int userID = _tokenHelper.GetUserID();
                var voucher = await _context.Voucher.FirstOrDefaultAsync(x => x.Code == code);
                if (voucher == null)
                {
                    return _response.ResponseError(StatusCodes.Status404NotFound, "Voucher không tồn tại !", null!);
                }
                if (voucher.ExpiryDate < DateTime.Now)
                {
                    return _response.ResponseError(StatusCodes.Status400BadRequest, "Voucher đã hết hạn !", null!);
                }
                if (voucher.MinimumPurchaseAmount > amount) 
                { 
                    return _response.ResponseError(StatusCodes.Status400BadRequest, "Không đủ điều kiện để sử dụng được voucher này !", null!);
                }

                var userVoucher = await _context.UserVoucher.FirstOrDefaultAsync(x => x.VoucherID == voucher.ID && x.UserID == userID);
                if (userVoucher != null)
                {
                    return _response.ResponseError(StatusCodes.Status400BadRequest, "Bạn đã sử dụng voucher này rồi !", null!);
                }

                var useVoucher = new UserVoucher { 
                    UserID = userID,
                    VoucherID = voucher.ID,
                };
                await _context.UserVoucher.AddAsync(useVoucher);
                await _context.SaveChangesAsync();

                return _response.ResponseSuccess("Sử dụng voucher thành công !", null!);
            }
            catch (Exception e)
            {
                return _response.ResponseError(StatusCodes.Status500InternalServerError, e.Message, null!);
            }
        }

        public async Task<ResponseObject<VoucherDTO>> CreateVoucher(VoucherRequest request)
        {
            try
            {
                InputHelper.VoucherValidate(request);
                if (request.ExpiryDate < DateTime.Now)
                {
                    return _response.ResponseError(StatusCodes.Status400BadRequest, "Thời gian hết hạn voucher không được nhỏ hơn ngày hiện tại !", null!);
                }

                var voucher = new Voucher
                {
                    Code = request.Code,
                    Title = request.Title,
                    DiscountPercentage = request.DiscountPercentage,
                    MinimumPurchaseAmount = request.MinimumPurchaseAmount,
                    ExpiryDate = request.ExpiryDate
                };

                await _context.Voucher.AddAsync(voucher);
                await _context.SaveChangesAsync();

                return _response.ResponseSuccess("Thêm voucher thành công !", _voucherConverter.EntityVoucherToDTO(voucher));
            }
            catch (Exception e)
            {
                return _response.ResponseError(StatusCodes.Status500InternalServerError, e.Message, null!);
            }
        }

        public async Task<PageResult<VoucherDTO>> GetAllVoucher(Pagination pagination)
        {
            var query = _context.Voucher.OrderByDescending(x => x.ID).AsQueryable();

            var result = PageResult<Voucher>.ToPageResult(pagination, query);
            pagination.TotalCount = await query.CountAsync();

            var list = result.ToList();

            return new PageResult<VoucherDTO>(pagination, _voucherConverter.ListEntityVoucherToDTO(result.ToList()));
        }

        public async Task<ResponseObject<VoucherDTO>> GetVoucherByID(int voucherID)
        {
            var voucher = await _context.Voucher.FirstOrDefaultAsync(x => x.ID == voucherID);
            if (voucher == null)
            {
                return _response.ResponseError(StatusCodes.Status404NotFound, "Voucher không tồn tại !", null!);
            }
            return _response.ResponseSuccess("Thành công !", _voucherConverter.EntityVoucherToDTO(voucher));
        }

        public async Task<ResponseObject<string>> RemoveVoucer(int voucherID)
        {
            var response = new ResponseObject<string>();
            var voucher = await _context.Voucher.FirstOrDefaultAsync(x => x.ID == voucherID);
            if (voucher == null)
            {
                return response.ResponseError(StatusCodes.Status404NotFound, "Voucher không tồn tại !", null!);
            }

            _context.Voucher.Remove(voucher);
            await _context.SaveChangesAsync();

            return response.ResponseSuccess("Xóa voucher thành công !", null!);
        }

        public async Task<ResponseObject<string>> RemoveVoucerByUser(int voucherID)
        {
            var response = new ResponseObject<string>();
            try
            {
                _tokenHelper.IsToken();
                int userID = _tokenHelper.GetUserID();
                var userVoucher = await _context.UserVoucher.FirstOrDefaultAsync(x => x.ID == voucherID && x.UserID == userID);
                if (userVoucher == null)
                {
                    return response.ResponseError(StatusCodes.Status404NotFound, "Voucher không tồn tại !", null!);
                }

                _context.UserVoucher.Remove(userVoucher);
                await _context.SaveChangesAsync();

                return response.ResponseSuccess("Thành công !", null!);
            }
            catch (Exception e)
            {
                return response.ResponseError(StatusCodes.Status500InternalServerError, e.Message, null!);
            }
        }

        public async Task<ResponseObject<VoucherDTO>> UpdateVoucher(int voucherID, VoucherRequest request)
        {
            try
            {
                InputHelper.VoucherValidate(request);
                var voucher = await _context.Voucher.FirstOrDefaultAsync(x => x.ID == voucherID);

                if (voucher == null)
                {
                    return _response.ResponseError(StatusCodes.Status404NotFound, "Voucher không tồn tại !", null!);
                }
                if (request.ExpiryDate < DateTime.Now)
                {
                    return _response.ResponseError(StatusCodes.Status400BadRequest, "Thời gian hết hạn voucher không được nhỏ hơn ngày hiện tại !", null!);
                }


                voucher.Code = request.Code;
                voucher.Title = request.Title;
                voucher.DiscountPercentage = request.DiscountPercentage;
                voucher.MinimumPurchaseAmount = request.MinimumPurchaseAmount;
                voucher.ExpiryDate = request.ExpiryDate;

                _context.Voucher.Update(voucher);
                await _context.SaveChangesAsync();

                return _response.ResponseSuccess("Cập nhật voucher thành công !", _voucherConverter.EntityVoucherToDTO(voucher));
            }
            catch (Exception e)
            {
                return _response.ResponseError(StatusCodes.Status500InternalServerError, e.Message, null!);
            }
        }
    }
}
