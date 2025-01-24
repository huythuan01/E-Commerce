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
    public class BranchRepository(AppDbContext appDbContext) :  IGenericRepositoryInterface<Branch>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDbContext.Branches.FindAsync(id);
            if (dep is null) return Notfound();
            
            appDbContext.Branches.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Branch>> GetAll() => await appDbContext.Branches.ToListAsync();

        public async Task<Branch> GetById(int id) => await appDbContext.Branches.FindAsync(id);

        public async Task<GeneralResponse> Insert(Branch item)
        {
            if (!await CheckName(item.Name!)) return new(false, "Department already added!");
            appDbContext.Branches.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Branch item)
        {
            var dep = await appDbContext.Branches.FindAsync(item.Id);
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
            var item = await appDbContext.Departments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
