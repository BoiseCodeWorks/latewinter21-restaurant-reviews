<template>
  <div class="reviewComponent col-3 card m-1">
    <h3>
      {{ reviewProp.title }}
      <i class="fa fa-trash text-danger" @click="deleteReview" v-if="reviewProp.ownerId == state.account.id" aria-hidden="true"></i>
    </h3>
    <h4>{{ reviewProp.body }}</h4>
    <p>{{ reviewProp.rating }}</p>
    <router-link :to="{name: 'Profile', params: {id:reviewProp.ownerId }}">
      <div class="row text-dark">
        <div class="col-5">
          <p>Made By: {{ reviewProp.owner.name }}</p>
        </div>
        <div class="col-7">
          <img class="img-fluid" :src="reviewProp.owner.picture" alt="">
        </div>
      </div>
    </router-link>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { reviewsService } from '../services/ReviewsService'
import { AppState } from '../AppState'
export default {
  name: 'ReviewComponent',
  props: {
    reviewProp: {
      type: Object,
      required: true
    }
  },
  // make sure setup takes in props especially if you need to reference a prop in a method
  setup(props) {
    const state = reactive({
      account: computed(() => AppState.account)
    })
    return {
      state,
      deleteReview() {
        // NOTE this was a problem when we deleted from our own page
        // reviewsService.deleteReview(props.reviewProp.id, props.reviewProp.restaurantId)
        // reviewsService.deleteReview(props.reviewProp)
        reviewsService.deleteReview(props.reviewProp.id)
      }
    }
  }
}
</script>

<style scoped>

</style>
