using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

using Newtonsoft.Json;

using FoodBookingAPI.Models;
using FoodBookingAPI.Repository;
using System.Diagnostics;

namespace FoodBookingAPI.Controllers
{
    public class CartItemController : ApiController
    {
        Dictionary<string, object> param;

        [Route("api/GetCartItemBySessionId/{SessionId}")]
        [HttpGet]
        public IHttpActionResult GetCartItemBySessionId(int SessionId)
        {
            try
            {
                param = null;
                param = new Dictionary<string, object>();

                param.Add(nameof(CartItems.SessionId), SessionId);

                DataTable result = CartItemRepository.GetCartItemBySessionId(param);
                if (result != null)
                    return Ok(result);
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("api/AddCartItem")]
        [HttpPost]
        public IHttpActionResult AddCartItem()
        {
            try
            {
                param = null;
                param = new Dictionary<string, object>();

                string content = Request.Content.ReadAsStringAsync().Result;
                CartItems newCartItem = JsonConvert.DeserializeObject<CartItems>(content);
                Debug.WriteLine(newCartItem.ProductId);
                param.Add(nameof(CartItems.SessionId), newCartItem.SessionId);
                param.Add(nameof(CartItems.ProductId), newCartItem.ProductId);
                param.Add(nameof(CartItems.Quantity), newCartItem.Quantity);
                param.Add(nameof(CartItems.CreatedDate), newCartItem.CreatedDate);
                param.Add(nameof(CartItems.ModifiedDate), newCartItem.ModifiedDate);
               
                bool success = CartItemRepository.AddCartItem(param);
                if (success == true)
                    return Ok();
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("api/UpdateCartItem")]
        [HttpPost]
        public IHttpActionResult UpdateCartItem()
        {
            try
            {
                param = null;
                param = new Dictionary<string, object>();
                string content = Request.Content.ReadAsStringAsync().Result;
                CartItems updatedCartItem = JsonConvert.DeserializeObject<CartItems>(content);

                param.Add(nameof(CartItems.CartItemId), updatedCartItem.CartItemId);
                param.Add(nameof(CartItems.SessionId), updatedCartItem.SessionId);
                param.Add(nameof(CartItems.ProductId), updatedCartItem.ProductId);
                param.Add(nameof(CartItems.Quantity), updatedCartItem.Quantity);
                param.Add(nameof(CartItems.CreatedDate), updatedCartItem.CreatedDate);
                param.Add(nameof(CartItems.ModifiedDate), updatedCartItem.ModifiedDate);

                bool success = CartItemRepository.UpdateCartItem(param);

                if (success == true)
                    return Ok();
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("api/DeleteCartItem/{ProductId}/{sessionId}")]
        [HttpDelete]
        public IHttpActionResult DeleteCartItem(int ProductId, int sessionId)
        {
            try
            {
                param = null;
                param = new Dictionary<string, object>();

                param.Add(nameof(CartItems.ProductId), ProductId);
                param.Add(nameof(CartItems.SessionId), sessionId);

                bool success = CartItemRepository.DeleteCartItem(param);
                if (success == true)
                    return Ok();
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
