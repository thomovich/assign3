using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Dataacces;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Assignment_2.Data
{
    public class SqliteAdultService : IAdultdata
    {
        private ViaDBContext ctx;

        public SqliteAdultService(ViaDBContext ctx)
        {
            this.ctx = ctx;
        }


        public async Task<Adult> AddAdult(Adult adult)
        {
            EntityEntry<Adult> newlyAdded = await ctx.Adults.AddAsync(adult);
            await ctx.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task RemoveAdult(int todoId)
        {
            Adult adult = await ctx.Adults.FindAsync(todoId);
            ctx.Adults.Remove(adult);
        }

        public async Task<Adult> UpdateAsync(Adult adult)
        {
            try
            {
                Adult toUpdate = await ctx.Adults.FirstAsync(a => a.Id == adult.Id);
                toUpdate = adult;
                ctx.Update(toUpdate);
                await ctx.SaveChangesAsync();
                return toUpdate;

            }
            catch (Exception e)
            {
                throw new Exception($"Did not find adult with id{adult.Id}");
            }
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            List<Adult> adults = await ctx.Adults.ToListAsync();
            return adults;
        }
    }
}