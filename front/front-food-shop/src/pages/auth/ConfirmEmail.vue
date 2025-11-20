<template>
  <div class="auth-container">
    <!-- Карточка -->
    <div class="auth-card">
      <!-- Заголовок -->
      <h1 class="auth-title">Подтвердите вашу почту</h1>

      <div class="info-message">Мы отправили код подтверждения на вашу почту</div>

      <!-- Форма -->
      <form @submit.prevent="handleRetry" class="auth-form">
        <div class="numbers-group">
          <div class="numbers-group-item">
            <input type="number" min="0" max="9"/>
            <input type="number" min="0" max="9"/>
            <input type="number" min="0" max="9"/>
          </div>
          <div class="numbers-group-item">
            <input type="number" min="0" max="9"/>
            <input type="number" min="0" max="9"/>
            <input type="number" min="0" max="9"/>
          </div>
        </div>
        <p v-if="errors" class="error-message">{{ errors }}</p>
        <!-- Submit -->
        <button
          type="submit"
          class="mt-4 text-sm text-orange-500 hover:underline rounded-xl"
          style="width: 362px; height: 48px; margin-top: 12px; background-color: F4F4F4;
          color: #555555; border-radius: 18px; border: none; font-size: 18px; font-weight: 600;">
          Запросить код повторно
        </button>
      </form>

      <!-- Create account -->
      <button
        type="submit"
        class="auth-button-submit"
        @click="handleAuth"
      >
        Далее
      </button>

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
import { sendVerificationEmail } from "@/services/api";

const errors = ref(null);

const handleRetry = () => {
  const email = localStorage.getItem("email");
  const email_response = sendVerificationEmail(email);
};

const handleAuth = () => {
  errors.value = null;
  if (!errors.value) errors.value = "Неверный код подтверждения Попробуйте еще раз или запросите код повторно";
  router.push("/finish-registration");
};

</script>

<style scoped>
@import './auth.css';
.email-placeholder::placeholder {
  transform: translateX(20px);
}
</style>