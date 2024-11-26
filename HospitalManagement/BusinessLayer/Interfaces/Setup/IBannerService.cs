using System.Collections.Generic;
using HospitalManagement.BusinessLayer.DTO;
using HospitalManagement.Models;

namespace HospitalManagement.BusinessLayer.Interface
{
    public interface IBannerService
    {
        List<BannerDTO> GetAllBanner();
        string GetValueByName(string BannerName);
        BannerDTO GetBannerById(string BannerName);
        bool DeleteBanner(int mnId);
        BannerDTO GetBannerByIdd(int MnId);
        int CreateBanner(BannerDTO BannerUI);
  
    }
}