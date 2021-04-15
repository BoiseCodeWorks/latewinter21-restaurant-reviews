<template>
  <div class="about container-fluid">
    <div class="row justify-content-center">
      <div class="col-6">
        <h1>Welcome {{ state.account.name }}</h1>
        <img class="rounded" :src="state.account.picture" alt="" />
        <p>{{ state.account.email }}</p>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h3>Create a restaurant</h3>
        <form @submit.prevent="createRestaurant">
          <input type="text" v-model="state.newRestaurant.name" placeholder="Enter a name">
          <input type="text" v-model="state.newRestaurant.location" placeholder="Enter a location">
          <button type="submit" class="btn btn-primary">
            Create Restaurant
          </button>
        </form>
      </div>
    </div>

    <div class="row">
      <review-component v-for="rev in state.reviews" :key="rev.id" :review-prop="rev" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { reviewsService } from '../services/ReviewsService'
import { restaurantService } from '../services/RestaurantService'
export default {
  name: 'Account',
  setup() {
    const state = reactive({
      account: computed(() => AppState.account),
      reviews: computed(() => AppState.reviews),
      newRestaurant: {}

    })
    onMounted(() => reviewsService.getReviewsByAccountId())
    return {
      state,
      createRestaurant() {
        restaurantService.createRestaurant(state.newRestaurant)
        state.newRestaurant = {}
      }
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
