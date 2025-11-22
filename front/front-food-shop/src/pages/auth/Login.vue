<template>
  <div class="page-bg">
    <div class="login-card">
      <h1 class="login-title">Вход</h1>

      <!-- Глобальные ошибки -->
      <div v-if="globalError.length" class="global-error">
        <ul>
          <li v-for="(err, index) in globalError" :key="index">{{ err }}</li>
        </ul>
      </div>

      <form @submit.prevent="handleSubmit" class="form">

        <!-- Email -->
        <div class="field-wrap">
          <div :class="['field', errors.email ? 'field-error' : '']">
            <input
              v-model="email"
              type="email"
              placeholder="Почта"
              class="input"
            />
          </div>
        </div>

        <!-- Password -->
        <div class="field-wrap">
          <div :class="['field', errors.password ? 'field-error' : '']">
            <input
              v-model="password"
              :type="showPassword ? 'text' : 'password'"
              placeholder="Пароль"
              class="input"
            />
            <button type="button" class="show-btn" @click="showPassword = !showPassword">
              {{ showPassword ? '🙈' : '👁️' }}
            </button>
          </div>
        </div>

        <!-- Remember + Forgot -->
        <div class="remember-forgot">
          <label class="remember">
            <input type="checkbox" v-model="remember" class="custom-checkbox" />
            <span>Запомнить меня</span>
          </label>
          <button type="button" class="forgot-btn" @click="handleForgot">Забыли пароль?</button>
        </div>

        <!-- Submit -->
        <button 
          type="submit" 
          class="submit-btn"
          :class="{ 'inactive-btn': !isFormValid }"
          :disabled="!isFormValid"
        >
          Войти
        </button>
      </form>

      <!-- Create account -->
      <button class="create-btn" @click="handleRegister">
        Создать аккаунт
      </button>

      <p class="contact-text">
        По всем вопросам можете обращаться:<br>
        adminexample@gmail.com
      </p>
    </div>
  </div>
</template>

<script setup>
import { ref, computed } from "vue";
import router from "@/router";
import { login } from "@/services/api";

const email = ref("");
const password = ref("");
const remember = ref(false);
const showPassword = ref(false);

const errors = ref({ email: false, password: false });
const globalError = ref([]);

// Кнопка активна только если введена корректная почта и пароль не пустой
const isFormValid = computed(() => email.value.includes("@") && password.value.length > 0);

const handleSubmit = async () => {
  errors.value = { email: false, password: false };
  globalError.value = [];

  if (!email.value) {
    errors.value.email = true;
    globalError.value.push("Почта не указана");
  } else if (!email.value.includes("@")) {
    errors.value.email = true;
    globalError.value.push("Неверный формат почты");
  }

  if (!password.value) {
    errors.value.password = true;
    globalError.value.push("Пароль не указан");
  }

  if (globalError.value.length) return;

  try {
    const email_response = await login(email.value, password.value);
    if (!email_response.ok) {
      throw new Error("Вход не удался: неверный логин или пароль");
    }
    localStorage.setItem("email", email.value);
    router.push("/finish-registration");
  } catch (error) {
    console.log(error);
    globalError.value.push(error.message);
  }
};

const handleRegister = () => {
  router.push("/register");
};

const handleForgot = () => {
  router.push("/forgot-password");
};
</script>

<style scoped>
@import './auth.css';

/* Стили для неактивной кнопки */
.submit-btn.inactive-btn {
  background-color: #FFA84C;
  color: white;
  cursor: not-allowed;
}

.submit-btn:enabled:hover {
  background-color: #ff7a00;
  color: white;
}
</style>