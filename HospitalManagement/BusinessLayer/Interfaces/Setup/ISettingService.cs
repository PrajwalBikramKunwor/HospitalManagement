using System.Collections.Generic;
using HospitalManagement.BusinessLayer.DTO;

namespace HospitalManagement.BusinessLayer.Interface
{
    public interface ISettingService
    {
        List<SettingDTO> GetAllSetting();
        string GetValueByName(string settingName);
        void UpdateSetting(SettingDTO settingUi);
        SettingDTO GetSettingById(string settingName);
    }
}