<template>
  <div id="app">
    <router-view :key="this.$route.path"/>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>
