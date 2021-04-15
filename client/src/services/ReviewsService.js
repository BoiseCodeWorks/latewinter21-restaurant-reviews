import { AppState } from '../AppState'
import { api } from './AxiosService'

class ReviewsService {
  async createReview(review) {
    const res = await api.post('api/reviews', review)
    console.log(res)
    // AppState.reviews = [...AppState.reviews, res.data]
    this.getRestaurantReviews(review.restaurantId)
  }

  async getRestaurantReviews(id) {
    const res = await api.get('api/restaurants/' + id + '/reviews')
    console.log(res)
    AppState.reviews = res.data
  }
  // this was an issue when we went to delete from our own page
  // async deleteReview(revId, restId) {
  //   await api.delete('api/reviews/' + revId)
  //   this.getRestaurantReviews(restId)
  // }

  async deleteReview(revId) {
    await api.delete('api/reviews/' + revId)
    const revIndex = AppState.reviews.findIndex(r => r.id === revId)
    AppState.reviews.splice(revIndex, 1)
  }

  async getReviewsByAccountId() {
    const res = await api.get('account/reviews')
    console.log(res)
    AppState.reviews = res.data
  }

  async getReviewsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/reviews')
    console.log(res)
    AppState.reviews = res.data
  }
}

export const reviewsService = new ReviewsService()
