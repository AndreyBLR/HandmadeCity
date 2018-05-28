using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandmadeCity.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace HandmadeCity.Services
{
    public class CartService : ICartService
    {
        private readonly string _listOfProductsInCartSessionKey = "ListOfProductsInCart";
        private readonly string _amountOfProductsInCartSessionKey = "AmountOfProductsInCart";


        public IList<int> Get(ISession session)
        {
            var listOfProductsInCartValue = session.GetString(_listOfProductsInCartSessionKey);
            if (!string.IsNullOrEmpty(listOfProductsInCartValue))
            {
                return JsonConvert.DeserializeObject<List<int>>(listOfProductsInCartValue);
            }

            return new List<int>();
        }

        public void Add(ISession session, int productId)
        {
            var listOfProductsInCartValue = session.GetString(_listOfProductsInCartSessionKey);
            if (!string.IsNullOrEmpty(listOfProductsInCartValue))
            {
                var deserializedProdList = JsonConvert.DeserializeObject<List<int>>(listOfProductsInCartValue);
                deserializedProdList.Add(productId);
                var serializedProdList = JsonConvert.SerializeObject(deserializedProdList);

                session.SetString(_listOfProductsInCartSessionKey, serializedProdList);
            }
            else
            {
                var newProdList = new List<int> { productId };
                var serializedProdList = JsonConvert.SerializeObject(newProdList);

                session.SetString(_listOfProductsInCartSessionKey, serializedProdList);
            }

            var amountOfProductsInCartValue = session.GetString(_amountOfProductsInCartSessionKey);
            if (!string.IsNullOrEmpty(amountOfProductsInCartValue))
            {
                var deserializedProdAmount = JsonConvert.DeserializeObject<int>(amountOfProductsInCartValue);
                deserializedProdAmount++;
                var serializedProdAmount = JsonConvert.SerializeObject(deserializedProdAmount);

                session.SetString(_amountOfProductsInCartSessionKey, serializedProdAmount);
            }
            else
            {
                session.SetString(_amountOfProductsInCartSessionKey, "1");
            }
        }

        public void Remove(ISession session, int productId)
        {
            var listOfProductsInCartValue = session.GetString(_listOfProductsInCartSessionKey);
            if (!string.IsNullOrEmpty(listOfProductsInCartValue))
            {
                var deserializedProdList = JsonConvert.DeserializeObject<List<int>>(listOfProductsInCartValue);
                if (deserializedProdList.Remove(productId))
                {
                    var serializedProdList = JsonConvert.SerializeObject(deserializedProdList);

                    session.SetString(_listOfProductsInCartSessionKey, serializedProdList);

                    var amountOfProductsInCartValue = session.GetString(_amountOfProductsInCartSessionKey);
                    if (!string.IsNullOrEmpty(amountOfProductsInCartValue))
                    {
                        var deserializedProdAmount = JsonConvert.DeserializeObject<int>(amountOfProductsInCartValue);
                        deserializedProdAmount--;
                        var serializedProdAmount = JsonConvert.SerializeObject(deserializedProdAmount);

                        session.SetString(_amountOfProductsInCartSessionKey, serializedProdAmount);
                    }
                }
            }
        }
    }
}
