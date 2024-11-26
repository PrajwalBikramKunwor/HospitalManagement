using System.Collections.Generic;
using System.Linq;
using HospitalManagement.BusinessLayer.DTO;
using HospitalManagement.DataAccessLayer.Model;

namespace HospitalManagement.BusinessLayer.Mapper
{
    public class ColorImagesMapper
    {
        public static List<ColorImagesDTO> GetAllColorImagesDTO(List<ColorImages> ColorImagesList)
        {

            var ColorImagesDTOList = ColorImagesList.Select(x => new ColorImagesDTO
            {
                ColorImagesId = x.ColorImagesId,
                ColorImagesName = x.ColorImagesName,
                StockId = x.StockId,
                ColorImagesImg = x.ColorImagesImg,
                ColorName = x.ColorName,
                ColorNamePicker = x.ColorNamePicker,
            }).ToList();

            return ColorImagesDTOList;
        }

        public static ColorImages GetColorImagesDAO(ColorImagesDTO x)
        {

            return new ColorImages()
            {
                ColorImagesId = x.ColorImagesId,
                ColorImagesName = x.ColorImagesName,
                StockId = x.StockId,
                ColorImagesImg = x.ColorImagesImg,
                ColorName = x.ColorImagesName,
                ColorNamePicker = x.ColorNamePicker,

            };          
        }

        public static ColorImagesDTO GetColorImagesDTO(ColorImages x)
        {

            return new ColorImagesDTO()
            {
                ColorImagesId = x.ColorImagesId,
                ColorImagesName = x.ColorImagesName,
                StockId = x.StockId,
                ColorImagesImg = x.ColorImagesImg,
                ColorName = x.ColorImagesName,
                ColorNamePicker = x.ColorNamePicker,

            };
        }
    }
}
