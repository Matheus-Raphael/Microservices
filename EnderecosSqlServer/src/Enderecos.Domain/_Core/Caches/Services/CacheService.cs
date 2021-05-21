using System.Runtime.Caching;

namespace Enderecos.Domain._Core.Caches.Services {

    public class CacheService {

        // Constantes
        //public const string LISTA_RECURSOS = "lista_recursos";
        //public const string LISTA_PERMISSOES = "lista_permissoes";

        // Atributos
        //private static CacheService _instance;

        // Propriedades
        //public static CacheService getInstance => _instance = _instance ?? new CacheService();

        /// <summary>
        /// Carregar itens em cache
        /// </summary>
        public T load<T>(string key) where T : class {

            var cache = MemoryCache.Default[key];

            var infoRetorn = cache as T;

            return infoRetorn;
        }

        /// <summary>
        /// salvar itens em cache
        /// </summary>
        public void save(string key, object valor) {

            if (valor == null) {
                return;
            }

            MemoryCache.Default[key] = valor;
        }
    }
}
