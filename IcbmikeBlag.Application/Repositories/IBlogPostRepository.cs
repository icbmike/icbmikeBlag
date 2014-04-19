using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IcbmikeBlag.Application.Repositories
{
    public interface IRepository<K, V> where V : IEntity<K>
    {
    
        IEnumerable<V> List(int num = 10, int page = 1);

        V GetBlogPost(K key);
      
        void Save(V value);

        void Delete(K key);

    }

    public interface IEntity<K>
    {
        K GetKey { get; set; }
    }
}
