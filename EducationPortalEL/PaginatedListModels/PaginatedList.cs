using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalEL.PaginatedListModels
{
    public class PaginatedList<T> : List<T>
    {
        public int TotalPages { get; set; }// toplam sayfa sayısı
        public int PageIndex { get; set; }  //hangi sayfada olduğum
        public bool NextPage
        {
            get
            {
                return PageIndex < TotalPages;

            }
        }  //sonraki sayfaya gidebilecek durumu var mı
        public bool PreviousPage
        {
            get
            {
                return PageIndex > 1;

            }
        } //önceki sayfaya gidebilecek durumu var mı
        public List<T> Data { get; set; } // sayfalama yapılacak veri
        public PaginatedList(List<T> data, int totalcount, int pageindex, int pageSize)
        {
            PageIndex = pageindex;
            Data = data;
            TotalPages = (int)Math.Ceiling(totalcount / (double)pageSize); //13 kişiyiz sayfada 2şer görmek istiyor = 7 sayfa
            //13 kişiyiz sayfada 3er görmek istiyor = 5 sayfa
        }
        public static PaginatedList<T> Create(List<T> data, int pageindex, int pagesize)
        {

            var items = data.
                //1) hangi sayfaya gitmek istiyorsam o sayfanın değerinden 1 tane eksiltip pagesize kadar veriyi atlayacağım
                Skip((pageindex - 1) * pagesize)
                //atladıktan sonra sayfada kaç adet veri gözükecekse o kadarını alıyoruz.
                .Take(pagesize).
                ToList();

            return new PaginatedList<T>(items, data.Count, pageindex, pagesize);

        }


    }
}
