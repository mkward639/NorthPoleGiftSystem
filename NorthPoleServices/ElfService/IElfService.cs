using System.Collections.Generic;
using System.Threading.Tasks;
using NorthPoleGiftSystem.Models.Elf;

namespace NorthPoleGiftSystem.NorthPoleServices
{
    public interface IElfService
    {
        Task<List<ElfListItem>> GetAllElves();
        ElfDetail GetElfById(int elfId);
        Task<bool> AddElfAsync(ElfCreate model);
        Task<bool> UpdateElfAsync(ElfUpdate model);
        void DeleteElf(int elfId);
    }
}
