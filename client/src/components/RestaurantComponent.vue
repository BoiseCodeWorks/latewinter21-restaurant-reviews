<template>
  <div class="restaurantComponent col-3 card">
    <!-- NOTE property inside param object MUST match param set in router.js for path name -->
    <router-link class="text-dark" :to="{name: 'RestaurantDetails', params: {restId : restProp.id}}">
      <h3>{{ restProp.name }}</h3>
      <p>We are located at :</p>
      <p>{{ restProp.location }}</p>
    </router-link>
  </div>
</template>

<script>
import { reactive } from 'vue'
export default {
  name: 'RestaurantComponent',
  props: {
    restProp: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive({

    })
    return { state }
  }
}
</script>

<style scoped>

</style>
