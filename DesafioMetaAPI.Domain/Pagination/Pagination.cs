using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioMetaAPI.Domain.Pagination
{
    public class Pagination<T>
    {
        /// <summary>
        /// Utilizado preferencialmente nos repositórios. Calcula automaticamente as
        /// propriedades <c>Total</c>, <c>Pages</c> e aplica <c>Skip</c> e <c>Limit</c> em <c>Results</c>.
        /// </summary>
        /// <param name="results">IQueryable da entidade.</param>
        /// <param name="offset">Quantidade de registros que devem ser pulados. Exemplo: <c>OffSet</c> == 1, pula 1 registro.</param>
        /// <param name="limit">Quantidade de registros por página.</param>
        /// <param name="page">Página que deseja consultar.</param>
        public Pagination(IQueryable<T> results, int? offset, int limit, int? page)
        {
            OffSet = offset;
            Limit = limit;
            Page = page;
            Total = results.Count();
            Results = results.Skip(Skip).Take(Limit).ToList();
            Pages = Math.Ceiling(Convert.ToDecimal(Total) / Convert.ToDecimal(Limit));
        }

        public Pagination(IQueryable<T> results, int? offset, int limit, int? page, long total)
        {
            OffSet = offset;
            Limit = limit;
            Page = page;
            Total = total;
            Results = results.Skip(Skip).Take(Limit).ToList();
            Pages = Math.Ceiling(Convert.ToDecimal(Total) / Convert.ToDecimal(Limit));
        }

        /// <summary>
        /// Utilizado quando já possui as propriedades calculadas e só quer preencher as informações.
        /// </summary>
        /// <param name="results">Lista com o resultado (já aplicado Skip e Take).</param>
        /// <param name="offset">Quantidade de registros que foram pulados.</param>
        /// <param name="limit">Quantidade de registros por página.</param>
        /// <param name="page">Página atual.</param>
        /// <param name="pages">Quantidade total de páginas.</param>
        /// <param name="total">Quantidade total de registros.</param>
        public Pagination(IEnumerable<T> results, int? offset, int limit, int? page, decimal pages, long total)
        {
            OffSet = offset;
            Limit = limit;
            Page = page;
            Total = total;
            Pages = pages;
            Results = results;
            Pages = Math.Ceiling(Convert.ToDecimal(Total) / Convert.ToDecimal(Limit));
        }

        public IEnumerable<T> Results { get; private set; }

        public int? OffSet { get; private set; }

        public int Limit { get; private set; } = 5;

        public int? Page { get; private set; }

        public decimal Pages { get; private set; }

        public long Total { get; private set; }

        private int Skip
        {
            get
            {
                if (OffSet.HasValue)
                {
                    return OffSet.Value;
                }
                else if (Page.HasValue)
                {
                    return (Page.Value - 1) * Limit;
                }
                else
                {
                    Page = 1;
                    OffSet = 0;
                    return 0;
                }
            }
        }
    }
}
