<template>
  <div class="ProfilePage container-fluid">
    <div class="row">
      <!-- <div class="col" v-if="state.loading"></div> -->
      <div class="col" v-if="!state.loading && state.profile.name">
        <h1>Welcome to {{ state.profile.name.includes('@') ? state.profile.name.split('@')[0] : state.profile.name }}'s Page </h1>
        <img :src="state.profile.picture" alt="">
      </div>
    </div>
    <div class="row">
      <review-component v-for="rev in state.reviews" :key="rev.id" :review-prop="rev" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { profilesService } from '../services/ProfileService'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { reviewsService } from '../services/ReviewsService'
export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      loading: true,
      profile: computed(() => AppState.profile),
      reviews: computed(() => AppState.reviews)
    })
    onMounted(() => {
      profilesService.getProfileById(route.params.id)
      state.loading = false
      reviewsService.getReviewsByProfileId(route.params.id)
    })
    return { state }
  }
}
</script>

<style scoped>

</style>
