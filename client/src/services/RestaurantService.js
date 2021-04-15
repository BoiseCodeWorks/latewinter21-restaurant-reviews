import { AppState } from '../AppState'
import { api } from './AxiosService'

class RestaurantService {
  async getRestaurants() {
    try {
      const res = await api.get('api/restaurants')
      console.log(res)
      AppState.restaurants = res.data
    } catch (error) {
      console.error(error)
    }
  }

  async getRestaurant(id) {
    try {
      const res = await api.get('api/restaurants/' + id)
      console.log(res)
      AppState.activeRestaurant = res.data
    } catch (error) {
      console.error(error)
    }
  }

  async createRestaurant(restaurant) {
    await api.post('api/restaurants', restaurant)
    this.getRestaurants()
  }
}
export const restaurantService = new RestaurantService()
