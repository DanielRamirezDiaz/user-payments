<script setup lang="ts">
import { ref } from "vue";
import TestService from '@/services/UserService'
import router, { routeNames } from "@/router";

const email = ref("DanielRamirezDiaz@outlook.com");

const Login = () => {
  TestService.Login(email.value)
    .then((data) => {
      sessionStorage.setItem('user', JSON.stringify(data.data));
      router.push({ name: routeNames.Payments });
    });
}

</script>

<template>
  <div>
    <label>Email</label>
    <input type="text" v-model="email">
    <button @click="Login">Login</button>
  </div>
</template>

