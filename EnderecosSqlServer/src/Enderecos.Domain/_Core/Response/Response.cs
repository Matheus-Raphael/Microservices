using System.Collections.Generic;

namespace Enderecos.Domain._Core.Response {
    public class Response<T> {

        public bool error { get; set; }

        public List<T> results { get; set; }

        public Response() {

            this.results = new List<T>();
        }
    }
}
