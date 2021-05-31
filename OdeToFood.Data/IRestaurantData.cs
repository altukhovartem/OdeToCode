using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
	public interface IRestaurantData
	{
		IEnumerable<Restaurant> GetRestaurantsByName(string name);
		Restaurant GetById(int id);
		Restaurant Update(Restaurant updatedRestairant);
		Restaurant Add(Restaurant restaurant);
		int Commit();
	}

	public class InMemoryRestaurantData : IRestaurantData
	{
		List<Restaurant> restaurants;
		public InMemoryRestaurantData()
		{
			restaurants = new List<Restaurant>
			{ 
				new Restaurant {Id = 1, Name = "First", Location = "Moscow", Cuisine = CuisineType.Indian},
				new Restaurant {Id = 2, Name = "Second", Location = "Montreal", Cuisine = CuisineType.Italian},
				new Restaurant {Id = 3, Name = "Third", Location = "Qwefv", Cuisine = CuisineType.Mexican}
			};
		}

		public Restaurant GetById(int id)
		{
			return restaurants.SingleOrDefault(r => r.Id == id);
		}

		public Restaurant Add(Restaurant newRestaurant)
		{
			restaurants.Add(newRestaurant);
			newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
			return newRestaurant;
		}

		public Restaurant Update(Restaurant updatedRestaurant)
		{
			var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
			if(updatedRestaurant != null)
			{
				restaurant.Name = updatedRestaurant.Name;
				restaurant.Location = updatedRestaurant.Location;
				restaurant.Cuisine = updatedRestaurant.Cuisine;
			}

			return restaurant;
		}

		public int Commit()
		{
			return 0;
		}

		public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
		{
			return from r in restaurants
				   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
				   orderby r.Name
				   select r;
		}
	}

}
