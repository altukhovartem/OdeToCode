using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
	public interface IRestaurantData
	{
		IEnumerable<Restaurant> GetAll();
	}

	public class InMemoryRestaurantData : IRestaurantData
	{
		List<Restaurant> restaurants;
		public InMemoryRestaurantData()
		{
			restaurants = new List<Restaurant>
			{ 
				new Restaurant {Id = 1, Name = "First", Location = "Moscow", Cuisine = CuisineType.Indian},
				new Restaurant {Id = 1, Name = "Second", Location = "Montreal", Cuisine = CuisineType.Italian},
				new Restaurant {Id = 1, Name = "Third", Location = "Qwefv", Cuisine = CuisineType.Mexican}
			};
		}

		public IEnumerable<Restaurant> GetAll()
		{
			return from r in restaurants
				   orderby r.Name
				   select r;
		}
	}

}
