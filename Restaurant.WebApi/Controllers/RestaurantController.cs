using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModel;
using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        //dependency injection
        private readonly IRestaurantService _restaurant;
        public RestaurantController(IRestaurantService restaurant)
        {
            _restaurant = restaurant;
        }


        // GET: api/<RestaurantController>
        [HttpGet]
        public IActionResult Get()
        {
            RestaurantViewModel r = _restaurant.GetRestaurants();
            if (r.Restaurants == null)
            {
                var response = new Domain.ResponsesModels.Response
                (
                    type: StatusCodes.Status404NotFound.ToString(),
                    message: "Restaurants Not Found!"
                );

                //log error

                //return view model
                return NotFound
                (
                    new RestaurantViewModel
                    {
                        Response = response
                    }
                );
            }
            return Ok(r);
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            RestaurantViewModel r = _restaurant.GetRestaurant(id);
            if (r.Restaurant == null)
            {
                var response = new Domain.ResponsesModels.Response
                    (
                        type: StatusCodes.Status400BadRequest.ToString(),
                        message: $"Restuarant with Id : {id} Not Found!"
                    );
                return NotFound(
                        new RestaurantViewModel()
                        {
                            Response = response
                        }
                    );

            }
            return Ok(r);
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public IActionResult Post([FromBody] Domain.Models.Restaurant Restaurant)
        {
            try
            {
                var createRestaurant = _restaurant.CreateRestaurant(Restaurant);
                    var response = new Domain.ResponsesModels.Response();
                    if(createRestaurant.Restaurant != null)
                    {
                        response.Type = StatusCodes.Status200OK.ToString();
                        response.Message = $"Successfully Created New Restaurant Named : {Restaurant.RestaurantName}";
                    }
                createRestaurant.Response = response;
                return Ok(createRestaurant);
            }
            catch (Exception e)
            { 
                var response = new Domain.ResponsesModels.Response(type: e.GetType().ToString(), e.Message);
                return Conflict(new RestaurantViewModel()
                    {
                        Response = response
                    }
                );
            }
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Domain.Models.Restaurant r)
        {
            //check if the ID is same
            if (id != r.Id)
            {
                //Create a new Response model
                var x = new Domain.ResponsesModels.Response(
                    type: StatusCodes.Status400BadRequest.ToString(),
                    message: $"Data Id Not Matched! {id} Not Same With Provided Data Id : {r.Id}!"
                    );

                //log with ToString Method

                //return x
                return BadRequest(
                        new RestaurantViewModel()
                        {
                            Response = x
                        }
                    );
            }
            var x_restaurant = _restaurant.GetRestaurant(id);
            if (x_restaurant.Restaurant == null)
            {
                //Create a new Response model
                var response = new Domain.ResponsesModels.Response(
                    type: StatusCodes.Status404NotFound.ToString(),
                    message: $"No Restaurant with Id : {id}"
                    );
                //log response with Response To String() Method
                //_logger.LogError(x.ToString());
                //return response in JSON Value

                return NotFound(new RestaurantViewModel()
                {
                    Response = response
                });
            }
            try
            {
                var restauranView = _restaurant.UpdateRestaurant(r);
                var response = new Domain.ResponsesModels.Response();
                if(restauranView.Restaurant != null)
                {
                    response.Type = StatusCodes.Status200OK.ToString();
                    response.Message = $"Successfully Updated {r.RestaurantName}";
                }
                restauranView.Response = response;
                return Ok(restauranView);
            }
            catch (Exception e)
            {
                var response = new Domain.ResponsesModels.Response(type: e.GetType().ToString(), e.Message);
                return Conflict(new RestaurantViewModel()
                {
                    Response = response
                });
            }
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var r = _restaurant.GetRestaurant(id);
            if (r.Restaurant == null)
            {
                var response = new Domain.ResponsesModels.Response(StatusCodes.Status404NotFound.ToString(), $"No Restaurant with Id ; {id}");
                return NotFound(new RestaurantViewModel()
                {
                    Response = response
                });
            }
            try
            {
                var x = _restaurant.DeleteRestaurant(r.Restaurant);
                if (x != true)
                {
                    var response = new Domain.ResponsesModels.Response
                        (
                            type: "Error Deleting", 
                            message: $"Failed To Delete Restaurant Name : {r.Restaurant.RestaurantName}"
                        );
                    return Conflict(new RestaurantViewModel
                    {
                        Response = response
                    });
                }
                else
                {
                    var response = new Domain.ResponsesModels.Response
                        (
                            StatusCodes.Status200OK.ToString(), 
                            $"Sucessfully Deleted Restaurant Named : {r.Restaurant.RestaurantName}"
                        );
                    return Ok(new RestaurantViewModel
                    {
                        Response = response
                    });
                }
            }
            catch (Exception e)
            {
                var response = new Domain.ResponsesModels.Response(type: e.GetType().ToString(), e.Message);
                return Conflict(new RestaurantViewModel()
                {
                    Response = response
                });
            }
        }
    }
}
