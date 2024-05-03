<template>
  <v-app>
    <v-main>
      <header-view>        </header-view>

      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script>
import HeaderView from './/components/Header/HeaderView';
 export default {
  name: 'App',

  components: {
    HeaderView
   },

  data: () => ({
    //
  }),
}
</script>
