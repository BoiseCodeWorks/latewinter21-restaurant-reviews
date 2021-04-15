<template>
  <div class="home flex-grow-1 container-fluid ">
    <div class="row align-items-center justify-content-center">
      <div class="col-3">
        <img src="https://bcw.blob.core.windows.net/public/img/8600856373152463" class="img-fluid" alt="CodeWorks Logo">
        <h1 class="my-5 bg-dark text-light p-3 rounded d-flex align-items-center text-center">
          <span class="mx-2 text-white">Restaurant Reviews</span>
        </h1>
      </div>
    </div>
    <div class="row">
      <restaurant-component v-for="r in state.restaurants" :key="r.id" :rest-prop="r" />
      <!-- prop gets its value from the first word in the v-for -->
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { restaurantService } from '../services/RestaurantService'
export default {
  name: 'Home',
  setup() {
    const state = reactive({
      restaurants: computed(() => AppState.restaurants)
    })
    onMounted(() => restaurantService.getRestaurants())
    return { state }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
