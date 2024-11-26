using System.Collections.Generic;
using System.Linq;
using HospitalManagement.BusinessLayer.DTO;
using HospitalManagement.DataAccessLayer.Model;

namespace HospitalManagement.BusinessLayer.Mapper
{
    public class BannerMapper
    {
        public static List<BannerDTO> GetAllBannerDTO(List<Banner> BannerList)
        {

            var BannerDTOList = BannerList.Select(x => new BannerDTO
            {
                BannerId = x.BannerId,
                BannerImg = x.BannerImg,
                BannerIsActive = x.BannerIsActive,
                BannerSortOrder = x.BannerSortOrder,

            }).ToList();

            return BannerDTOList;
        }

        public static Banner GetBannerDAO(BannerDTO x)
        {

            return new Banner()
            {
                BannerId = x.BannerId,
                BannerImg = x.BannerImg,
                BannerIsActive = x.BannerIsActive,
                BannerSortOrder = x.BannerSortOrder,
            };          
        }

        public static BannerDTO GetBannerDTO(Banner x)
        {

            return new BannerDTO()
            {
                BannerId = x.BannerId,
                BannerImg = x.BannerImg,
                BannerIsActive = x.BannerIsActive,
                BannerSortOrder = x.BannerSortOrder,


            };
        }
    }
}
