<template>
  <div class="restaurantPage container-fluid">
    <div class="row">
      <div class="col-12 text-center">
        <h5>
          {{ state.restaurant.name }}
        </h5>
        <h3>Located at: {{ state.restaurant.location }} </h3>
      </div>
    </div>
    <div class="row">
      <div class="col-4" v-if="state.showForm">
        <h3>Create a review!</h3>
        <form @submit.prevent="createReview">
          <div class="form-group">
            <input type="text"
                   class="form-control"
                   aria-describedby="helpId"
                   v-model="state.newReview.title"
            >
            <input type="text"
                   class="form-control"
                   aria-describedby="helpId"
                   v-model="state.newReview.body"
            >
            <input type="range" max="5" min="0" v-model="state.newReview.rating">
            <label for="">{{ state.newReview.rating }}</label>
            <input type="checkbox" v-model="state.newReview.published">
          </div>
          <button type="submit" class="btn btn-info">
            Create Review
          </button>
        </form>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h3>Reviews : <i class="fa fa-plus text-success" aria-hidden="true" @click="state.showForm = !state.showForm"></i> </h3>
      </div>
      <review-component v-for="rev in state.reviews" :key="rev.id" :review-prop="rev" />
    </div>
  </div>
</template>

<script>
import { onMounted, reactive, computed } from 'vue'
import { restaurantService } from '../services/RestaurantService'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { reviewsService } from '../services/ReviewsService'
export default {
  name: 'RestaurantPage',
  setup() {
    // this give access to route params
    const route = useRoute()
    const state = reactive({
      restaurant: computed(() => AppState.activeRestaurant),
      newReview: { },
      reviews: computed(() => AppState.reviews),
      showForm: false
    })
    onMounted(() => {
      // allows you to retrieve one restaurants info on refresh or page load

      restaurantService.getRestaurant(route.params.restId)
      reviewsService.getRestaurantReviews(route.params.restId)
    })
    return {
      state,
      createReview() {
        console.log(state.newReview)
        state.newReview.restaurantId = route.params.restId
        reviewsService.createReview(state.newReview)
        state.newReview = {}
        state.showForm = false
      }
    }
  }
}
</script>

<style scoped>

</style>
