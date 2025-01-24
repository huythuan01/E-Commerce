using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Implementations
{
    public class GeneralDepartmentRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<GeneralDepartment>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDbContext.GeneralDepartments.FindAsync(id);
            if (dep is null) return Notfound();

            appDbContext.GeneralDepartments.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<GeneralDepartment>> GetAll()
        {
            return await appDbContext.GeneralDepartments.ToListAsync();
        }

        public async Task<GeneralDepartment> GetById(int id)
        {
            return await appDbContext.GeneralDepartments.FindAsync(id);
        }

        public async Task<GeneralResponse> Insert(GeneralDepartment item)
        {
            if (!await CheckName(item.Name!)) return new(false, "Department already added!");
            appDbContext.GeneralDepartments.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(GeneralDepartment item)
        {
            var dep = await appDbContext.GeneralDepartments.FindAsync(item.Id);
            if (dep is null) return Notfound();
            dep.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse Notfound() => new(false, "Sorry, the department was not found!");
        private static GeneralResponse Success() => new(true, "The operation was successful!");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.GeneralDepartments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
