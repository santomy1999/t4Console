using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using t4Console.Models;

namespace t4Console.Repository
{
    public class FieldRepo
    {
        public readonly CGDBContext _dbContext;
        public FieldRepo(CGDBContext cgdbContext)
        {
            _dbContext = cgdbContext;
        }
        public async Task<Page> getPage(int pageId)
        {
			return await _dbContext.Pages.FindAsync(pageId);
        }
        public async Task<List<Page>> getAllPages()
        {
			return await _dbContext.Pages.ToListAsync();
        }
        public async Task<List<Field>> getFields(int pageId)
        {
			return await _dbContext.Fields.Where(f=>f.PageId==pageId).OrderBy(f=>f.Sequence).ToListAsync();
        }
        public async Task<List<Domain>> GetPageDomains(int pageId)
        {
            return await _dbContext.Domains.Where(d => d.PageId == pageId).OrderBy(d => d.DomainSeq).ToListAsync();
           
        }
        public async Task<List<Field>> getRequiredConditionFields(int pageId)
        {
            return await _dbContext.Fields.Where(f=>f.PageId==pageId && f.ReqCondition!=null ).ToListAsync();
        }
        public async Task<List<Domain>> GetFieldDomains(int FieldId)
        {
           return await _dbContext.Domains.Where(d => d.FieldId == FieldId).OrderBy(d => d.DomainSeq).ToListAsync();
            
        }
    }
}
