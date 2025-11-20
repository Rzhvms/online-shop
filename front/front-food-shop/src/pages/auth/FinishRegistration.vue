<template>
  <div class="auth-container">
    <!-- Карточка -->
    <div class="auth-card">
      <!-- Заголовок -->
      <h1 class="auth-title">Завершение регистрации</h1>

      <!-- Форма -->
      <form @submit.prevent="handleSubmit" class="auth-form">
        <div class="auth-email">
          <p>Введите ваше имя: </p>
          <input
            type="text"
            placeholder="Олег"
            class="auth-email-input"/>
        </div>

        <div class="auth-email">
          <p>Введите вашу фамилию: </p>
          <input
            type="text"
            placeholder="Волков"
            class="auth-email-input"/>
        </div>

        <div class="auth-email">
          <p>Ваш пол: </p>
          <input
            type="checkbox"
            placeholder="Женский/Мужской"
            class="auth-email-input"/>
        </div>

        <div class="auth-email">
          <p>Введите ваш номер телефона</p>
          <input
            type="tel"
            placeholder="+7 (...) ...-..-.."
            class="auth-email-input"/>
        </div>

        <!-- Submit -->
        <button
          type="submit"
          class="auth-button-submit">
          Завершить
        </button>
      </form>
      <p class="info-message">
        По всем вопросам можете обращаться:<br>
        adminexample@gmail.com
      </p>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
import router from "@/router";
import { createUser } from "@/services/api";

const name = ref("");
const lastName = ref("");
const gender = ref("");
const phone = ref("");

const handleSubmit = () => {
  const email = localStorage.getItem("email");
  const email_response = createUser(email, password.value, name.value, lastName.value, claims.value);
  router.push("/admin");
};
</script>

<style scoped>
@import './auth.css';
.email-placeholder::placeholder {
  transform: translateX(20px);
}
</style>
