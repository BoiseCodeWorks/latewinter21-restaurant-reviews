import { AppState } from '../AppState'
import { api } from './AxiosService'

class ProfilesService {
  async getProfileById(profId) {
    console.log(profId)
    const res = await api.get('api/profiles/' + profId)
    console.log(res)
    AppState.profile = res.data
  }
}

export const profilesService = new ProfilesService()
