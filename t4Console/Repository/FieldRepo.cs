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
            var pages = await _dbContext.Pages.FindAsync("1");
            return pages;
        }
        public async Task<List<Page>> getAllPages()
        {
            var pages = await _dbContext.Pages.ToListAsync();
            return pages;
        }
        public async Task<List<Field>> getFields(int pageId)
        {
            var fields = await _dbContext.Fields.Where(f=>f.PageId==pageId).OrderBy(f=>f.Sequence).ToListAsync();

            return fields;
        }
        public async Task<List<Domain>> GetPageDomains(int pageId)
        {
            var domain = await _dbContext.Domains.Where(d => d.PageId ==pageId).OrderBy(f => f.DomainSeq).ToListAsync();
            return domain;
        }
    }
}
