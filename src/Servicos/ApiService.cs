using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Servicos
{
    public class ApiService
    {
            private readonly string _vannonUrl = ConfigurationManager.AppSettings["SantaFarmaApiUrl"];
            private readonly string _vannonToken = ConfigurationManager.AppSettings["SantaFarmaApiToken"];

            public HttpClient CriarHttpClient(string urlComplement)
            {
                // var client = new HttpClient { BaseAddress = new Uri(_vannonUrl + urlComplement)};
                var client = new HttpClient { BaseAddress = new Uri(_vannonUrl + urlComplement) };
                //  client.DefaultRequestHeaders.Add("Authorization", $"ApiKey dan: {_vannonToken}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client;
            }
            public VannonProduto BuscarTodosProdutos()
            {
                var client = CriarHttpClient($"/productstore");
                var response = client.GetAsync($"{_vannonUrl}/productstore").Result;
                if (!response.IsSuccessStatusCode) return null;
                var produto = response.Content.ReadAsAsync<IEnumerable<VannonProduto>>().Result;
                return produto.Any() ? produto.First() : null;
            }
            public List<VannonProduto> BuscarTodosProdutos2()
            {

                var client = new HttpClient();

                var uri = new Uri($"{_vannonUrl}/productstore");

                var response = client.GetAsync(uri).Result;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;
                responseString = "[" + responseString + "]";
                dynamic tasks = JArray.Parse(responseString) as JArray;
                var dtotasks = new List<VannonProduto>();
                //foreach (var obj in tasks)
                //{
                //    var dto = new VannonProduto
                //    {
                //        barcode = obj.barcode,
                //        registroMS = obj.registroMS,
                //        description = obj.description,
                //        store_id = Convert.ToInt32(obj.store_id),
                //        quantity = Convert.ToInt32(obj.quantity),
                //        value = Convert.ToDecimal(obj.value)
                //        //discount = Convert.ToDecimal(obj.discount),
                //        //situation = Convert.ToInt32(obj.situation)
                //        //groupId = obj.groupId,
                //        //promotion = obj.promotion,
                //        //medicine = obj.medicine
                //        //productCategoryId = obj.productCategoryId,
                //        //productDefinitionId = obj.productDefinitionId,
                //        //productManufacturerId = obj.productManufacturerId
                //        //        productSubCategoryId = obj.productSubCategoryId
                //    };

                //    dtotasks.Add(dto);
                //}
                return dtotasks;
            }
            public VannonProduto BuscarProdutoPorEan(string ean)
            {

                var client = new HttpClient();

                var uri = new Uri($"{_vannonUrl}/productstore/{ean}");

                var response = client.GetAsync(uri).Result;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;
                responseString = "[" + responseString + "]";
                dynamic tasks = JArray.Parse(responseString) as JArray;
                var dtotasks = new List<VannonProduto>();
                foreach (var obj in tasks)
                {
                    var dto = new VannonProduto
                    {
                        barcode = obj.barcode,
                        registroMS = obj.registroMS,
                        description = obj.description,
                        store_id = Convert.ToInt32(obj.store_id),
                        quantity = Convert.ToInt32(obj.quantity),
                        value = Convert.ToDecimal(obj.value)
                        //discount = Convert.ToDecimal(obj.discount),
                        //situation = Convert.ToInt32(obj.situation)
                        //groupId = obj.groupId,
                        //promotion = obj.promotion,
                        //medicine = obj.medicine
                        //productCategoryId = obj.productCategoryId,
                        //productDefinitionId = obj.productDefinitionId,
                        //productManufacturerId = obj.productManufacturerId
                        //        productSubCategoryId = obj.productSubCategoryId
                    };

                    dtotasks.Add(dto);
                }
                return dtotasks.Any() ? dtotasks.First() : null;
            }
            public async Task<bool> CriarProduto(SyncProduto produto)
            {
                var client = CriarHttpClient("/productstore");
                var produtoJson = ConvertProdutoToJson(produto);
                var response = await client.PostAsync($"{_vannonUrl}/productstore",
                    new StringContent(produtoJson, Encoding.UTF8, "application/json"));
                return response.IsSuccessStatusCode;
            }
            public async Task<bool> DeletarProduto(SyncProduto produto)
            {
                var client = CriarHttpClient("/productstore");
                var produtoJson = ConvertProdutoToJson(produto);
                var response = await client.DeleteAsync($"{_vannonUrl}/productstore");
                return response.IsSuccessStatusCode;
            }
            public async Task<bool> AtualizarProduto(SyncProduto produto)
            {
                var client = CriarHttpClient("/productstore");
                var produtoJson = ConvertProdutoToJson(produto);
                var response = await client.PutAsync($"{_vannonUrl}/productstore",
                    new StringContent(produtoJson, Encoding.UTF8, "application/json"));
                return response.IsSuccessStatusCode;
            }
            public VannonProdutoSku BuscaProdutoSkuPorEan(string ean)
            {
                var client = CriarHttpClient($"/sku?$filter=CodigoExterno eq '{ean}'");
                var response = client.GetAsync($"{_vannonUrl}/sku?$filter=CodigoExterno eq '{ean}'").Result;
                if (!response.IsSuccessStatusCode) return null;
                var produto = response.Content.ReadAsAsync<IEnumerable<VannonProdutoSku>>().Result;
                return produto.Any() ? produto.First() : null;
            }
            public async Task<bool> CriarProdutoSku(VannonProdutoSku produtoSku)
            {
                var client = CriarHttpClient("/sku");
                var produtoSkuJson = ConvertProdutoSkuToJson(produtoSku);
                var response = await client.PostAsync($"{_vannonUrl}/sku",
                    new StringContent(produtoSkuJson, Encoding.UTF8, "application/json"));
                return response.IsSuccessStatusCode;
            }
            public async Task<bool> CriarProdutoPraca(VannonProdutoPraca produtoPraca)
            {
                var client = CriarHttpClient("/produtopraca");
                var produtoPracaJson = ConvertProdutoPracaToJson(produtoPraca, true);
                var response = await client.PostAsync($"{_vannonUrl}/produtopraca",
                    new StringContent(produtoPracaJson, Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    var produtoPracaJsonRetry = ConvertProdutoPracaToJson(produtoPraca, false);
                    var responseRetry = await client.PostAsync($"{_vannonUrl}/produtopraca",
                        new StringContent(produtoPracaJsonRetry, Encoding.UTF8, "application/json"));
                    return responseRetry.IsSuccessStatusCode;
                }
                return response.IsSuccessStatusCode;
            }
            public async Task<bool> AtualizarProdutoSku(VannonProdutoSku produtoSku)
            {
                var client = CriarHttpClient("/sku");
                var produtoSkuJson = ConvertProdutoSkuToJson(produtoSku);
                var response = await client.PutAsync($"{_vannonUrl}/sku",
                    new StringContent(produtoSkuJson, Encoding.UTF8, "application/json"));
                return response.IsSuccessStatusCode;
            }
            public async Task<bool> AtualizarProdutoPraca(VannonProdutoPraca produtoPraca)
            {
                var client = CriarHttpClient("/produtopraca");
                var produtoPracaJson = ConvertProdutoPracaToJsonForUpdate(produtoPraca, true);
                //Atualização parcial
                var httpRequestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), $"{_vannonUrl}/produtopraca")
                {
                    Content = new StringContent(produtoPracaJson, Encoding.UTF8, "application/json")
                };
                var response = await client.SendAsync(httpRequestMessage);
                //var error = response.Content.ReadAsAsync<object>().Result;
                if (!response.IsSuccessStatusCode)
                {
                    var produtoPracaJsonRetry = ConvertProdutoPracaToJsonForUpdate(produtoPraca, false);
                    var httpRequestMessageRetry = new HttpRequestMessage(new HttpMethod("PATCH"), $"{_vannonUrl}/produtopraca")
                    {
                        Content = new StringContent(produtoPracaJsonRetry, Encoding.UTF8, "application/json")
                    };
                    var responseRetry = await client.SendAsync(httpRequestMessageRetry);
                    //var error2 = responseRetry.Content.ReadAsAsync<object>().Result;
                    return responseRetry.IsSuccessStatusCode;
                }
                return response.IsSuccessStatusCode;
            }
            private static string ConvertProdutoToJson(SyncProduto produto)
            {
                var produtoJson =
                    "[{ \"barcode\": \"" + produto.Barras + "\", " +
                    "\"registroMS\": \"OCP0003\", " +
                    "\"description\": \"" + produto.Descricao + "\", " +
                    "\"store_id\":  1, " +
                    "\"quantity\": " + produto.Quantidade + ", " +
                    "\"PreVenda\": \"" + produto.Preco.ToString().Replace(",", ".") + "\", " +
                    "\"value\": " + produto.Preco.ToString().Replace(",", ".") + ", " +
                    "\"discount\": 0, " +
                    "\"situation\":  1, " +
                    "\"medicine\": \"N\", " +
                    "\"promotion\":  0, " +
                    "\"productDefinitionId\":  1, " +
                    "\"productManufacturerId\":  1, " +
                    "\"productCategoryId\":  1, " +
                    "\"productSubCategoryId\":  1 }]";
                return produtoJson;
            }
            private static string ConvertProdutoSkuToJson(VannonProdutoSku produtoSku)
            {
                var produtoSkuJson =
                    "[{ \"CodigoProduto\": \"" + produtoSku.CodigoProduto + "\", " +
                    "\"Brinde\": false, " +
                    "\"CodigoExterno\": \"" + produtoSku.CodigoExterno + "\", " +
                    "\"CodigoBarras\": \"" + produtoSku.CodigoBarras + "\", " +
                    "\"Peso\":  0.050, " +
                    "\"Altura\": 1, " +
                    "\"Largura\": 1, " +
                    "\"Profundidade\": 1, " +
                    "\"Nome\": \"" + produtoSku.Nome + "\", " +
                    "\"CodigoMS\": \"\" }]";
                return produtoSkuJson;
            }
            private static string ConvertProdutoPracaToJson(VannonProdutoPraca produtoPraca, bool clearLeftZeros)
            {
                var precoDe = produtoPraca.PrecoDe.ToString().Replace(",", ".");
                if (precoDe.Length == 1) precoDe += ".0";
                var precoPor = produtoPraca.PrecoPor.ToString().Replace(",", ".");
                if (precoPor.Length == 1) precoPor += ".0";
                var produtoPracaJson =
                    "[{ \"CodigoProdutoSku\": \"" + (clearLeftZeros ? produtoPraca.CodigoProdutoSku.TrimStart('0') : produtoPraca.CodigoProdutoSku) + "\", " +
                    "\"CodigoPraca\": \"41\", " +
                    "\"Ativo\": true, " +
                    "\"Estoque\": " + produtoPraca.Quantidade + ", " +
                    "\"EstoqueMinimo\": null, " +
                    "\"PrazoPostagem\": null, " +
                    "\"Desconto\": 0.0, " +
                    "\"InicioPromocao\": null, " +
                    "\"FimPromocao\": null, " +
                    "\"PrecoDe\": " + precoDe + ", " +
                    "\"PrecoPor\": " + precoPor + ", " +
                    "\"PromocaoPrecoDe\": null, " +
                    "\"PromocaoPrecoPor\": null, " +
                    "\"EmbalagemPresente\": null }]";
                return produtoPracaJson;
            }
            private static string ConvertProdutoPracaToJsonForUpdate(VannonProdutoPraca produtoPraca, bool clearLeftZeros)
            {
                var precoDe = produtoPraca.PrecoDe.ToString().Replace(",", ".");
                if (precoDe.Length == 1) precoDe += ".0";
                var precoPor = produtoPraca.PrecoPor.ToString().Replace(",", ".");
                if (precoPor.Length == 1) precoPor += ".0";
                var produtoPracaJson =
                    "[{ \"CodigoProdutoSku\": \"" + (clearLeftZeros ? produtoPraca.CodigoProdutoSku.TrimStart('0') : produtoPraca.CodigoProdutoSku) + "\", " +
                    "\"CodigoPraca\": \"41\", " +
                    "\"Estoque\": " + produtoPraca.Quantidade + ", " +
                    "\"PrecoDe\": " + precoDe + ", " +
                    "\"PrecoPor\": " + precoPor + " }]";
                return produtoPracaJson;
            }
        }
    }