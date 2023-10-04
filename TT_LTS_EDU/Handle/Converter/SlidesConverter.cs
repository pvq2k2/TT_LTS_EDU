using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class SlidesConverter
    {
        public SlidesDTO EntitySlidesToDTO(Slides slides)
        {
            return new SlidesDTO { 
                Image = slides.Image,
                Status = slides.Status,
            };
        }

        public List<SlidesDTO> ListEntitySlidesToDTO(List<Slides> listSlides) {
            var listSlidesDTO = new List<SlidesDTO>();
            foreach (var item in listSlides)
            {
                listSlidesDTO.Add(EntitySlidesToDTO(item));
            }

            return listSlidesDTO;
        }
    }
}
