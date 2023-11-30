using System.Collections.Generic;
using System.Threading.Tasks;
using NorthPoleGiftSystem.Models.WorkshopModel;

namespace NorthPoleGiftSystem.NorthPoleServices
{
    public interface IWorkshopService
    {
        Task<List<WorkshopListItem>> GetAllWorkshops();
        WorkshopDetail GetWorkshopById(int workshopId);
        Task<bool> AddWorkshopAsync(WorkshopCreate model);
        Task<bool> UpdateWorkshopAsync(WorkshopUpdate model);
        Task<bool> DeleteWorkshopAsync(int workshopId);
    }
}
