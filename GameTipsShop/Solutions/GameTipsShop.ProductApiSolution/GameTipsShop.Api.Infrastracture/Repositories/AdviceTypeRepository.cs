using System.Linq.Expressions;
using GameTipsShop.Api.Application.Interfaces;
using GameTipsShop.Api.Domain.Entities;
using GameTipsShop.Api.Infrastructure.Data;
using GameTipsShop.SharedLibrary.Logs;
using GameTipsShop.SharedLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GameTipsShop.Api.Infrastructure.Repositories
{
    public class AdviceTypeRepository(AdviceTypeDbContext context) : IAdviceType
    {
        public async Task<Response> CreateAsync(AdviceType entity)
        {
            try
            {
                var getAdviceType = await GetByAsync(_ => _.Name!.Equals(entity.Name));
                if (getAdviceType != null && !entity.Name.IsNullOrEmpty())
                {
                    return new Response(false, $"Error, {entity.Name} already exists");
                }
                
                var currentEntity = context.AdviceTypes.Add(entity).Entity;
                await context.SaveChangesAsync();

                if (currentEntity != null && currentEntity.Id > 0) //TODO CHECK why is always true
                {
                    return new Response(true, $"{entity.Name} added to database successfully");
                }
                else
                {
                    return new Response(false, $"Error occurred while adding {entity.Name}");
                }
            }
            catch (Exception ex)
            {
               LogException.LogExceptions(ex);
               return new Response(false, "Error");
            }
        }

        public async Task<Response> UpdateAsync(AdviceType entity)
        {
            try
            {
                var adviceType = await FindByIdAsync(entity.Id);
                if (adviceType is null)
                {
                    return new Response(false, $"{entity.Name} was not found in database");
                }

                context.Entry(adviceType).State = EntityState.Detached;
                context.AdviceTypes.Update(entity);
                await context.SaveChangesAsync();
                return new Response(true, $"{entity.Name} is updated successfully");
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                return new Response(false, "Error");
            }
        }

        public async Task<Response> DeleteAsync(AdviceType entity)
        {
            try
            {
                var adviceType = await FindByIdAsync(entity.Id);

                if (adviceType is null)
                {
                    return new Response(false, $"{entity.Name} was not found in database");
                }

                context.AdviceTypes.Remove(adviceType);
                await context.SaveChangesAsync();

                return new Response(true, $"{entity.Name} is deleted successfully");
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                return new Response(false, "Error");
            }
        }

        public async Task<IEnumerable<AdviceType>> GetAllAsync()
        {
            try
            {
                var adviceTypes = await context.AdviceTypes.AsNoTracking().ToListAsync();
                return adviceTypes is not null ? adviceTypes : null!;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception("Error retrieving adviceType");
            }
        }

        public async Task<AdviceType> FindByIdAsync(int id)
        {
            try
            {
                var adviceType = await context.AdviceTypes.FindAsync(id);
                return adviceType is not null ? adviceType : null!;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
               throw new Exception("Error retrieving adviceType");
            }
        }

        public async Task<AdviceType> GetByAsync(Expression<Func<AdviceType, bool>> predicate)
        {
           
            try
            {
                var adviceType = await context.AdviceTypes.Where(predicate).FirstOrDefaultAsync();
                return adviceType is not null ? adviceType : null!;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception("Error retrieving adviceType");
            }
        }
    }
}
