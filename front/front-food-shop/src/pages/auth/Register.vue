<template>
  <div class="auth-container">
    <!-- Карточка -->
    <div class="auth-card">
      <!-- Заголовок -->
      <h1 class="auth-title">Регистрация</h1>

      <!-- Форма -->
      <form @submit.prevent="handleSubmit" class="auth-form">

      <!-- Email -->
      <div class="auth-email">
        <div class="auth-email-div {{ errors.email ? 'error' : '' }}">
          <input
            v-model="email"
            type="email"
            placeholder="Почта"
            class="auth-email-input"/>
        </div>
        <p v-if="errors.email" class="error-message">{{ errors.email }}</p>
      </div>

        <!-- Password -->
        <div class="auth-email" style="margin-bottom: 0px;">
          <div class="auth-email-div {{ errors.password ? 'error' : '' }}">
            <input
              v-model="password"
              :type="showPassword ? 'text' : 'password'"
              placeholder="Пароль"
              class="auth-email-input"
              @input="checkPasswordStrength"/>

            <!-- SHOW / HIDE внутри поля -->
            <button
              type="button"
              class="auth-button"
              @click="showPassword = !showPassword"
            >
              {{ showPassword ? '🙈' : '👁️' }}
            </button>
          </div>
          <p class="info-message" style="font-size: 16px; display:flex;">Сложность пароля:</p>
          <div v-if="password.length > 0" class="password-strength">
            <div class="strength-bar" :class="strengthClass"></div>
            <span class="strength-text">{{ strengthText }}</span>
          </div>
        </div>

        <p class="info-message">
        Пароль должен содержать не менее 8 символов, включая латинские буквы (a-z, A-Z), как минимум одну заглавную букву и одну цифру
        </p>

        <!-- Submit -->
        <button
          type="submit"
          class="auth-button-submit">
          Далее
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
import { ref, computed } from "vue";
import { useRouter } from "vue-router";

const router = useRouter();
const email = ref("");
const password = ref("");
const remember = ref(false);
const showPassword = ref(false);

const errors = ref({ email: null, password: null });
const globalError = ref(null);

const passwordStrength = ref(0);

const handleSubmit = () => {
  errors.value = { email: null, password: null };
  globalError.value = null;

  if (!email.value) errors.value.email = "Указана неправильная почта";
  if (!password.value) errors.value.password = "Пароль";

  if (email.value && !email.value.includes("@")) {
    errors.value.email = "Неверный формат почты";
  }

  if (!errors.value.email && !errors.value.password) {
    if (email.value !== "test@mail.com" || password.value !== "123456") {
      globalError.value = "Аккаунт не найден";
      return;
    }
    console.log("Успешный вход:", email.value, password.value, remember.value);
  }
};

const checkPasswordStrength = () => {
  let strength = 0;
  const pass = password.value;

  if (pass.length > 0) {
    if (pass.length >= 8) {
      strength += 1;
    }
    if (pass.match(/[a-z]/) && pass.match(/[A-Z]/)) {
      strength += 1;
    }
    if (pass.match(/[0-9]/)) {
      strength += 1;
    }
  }
  passwordStrength.value = Math.min(strength, 3);
};

const strengthClass = computed(() => {
  switch (passwordStrength.value) {
    case 1:
      return "strength-weak";
    case 2:
      return "strength-medium";
    case 3:
      return "strength-strong";
    default:
      return "strength-weak";
  }
});

const strengthText = computed(() => {
  switch (passwordStrength.value) {
    case 1:
      return "Слабый";
    case 2:
      return "Средний";
    case 3:
      return "Сильный";
    default:
      return "Слабый";
  }
});
</script>

<style scoped>
@import './auth.css';
.email-placeholder::placeholder {
  transform: translateX(20px);
}
.password-strength {
  margin-top: 8px;
  margin-bottom: 8px;
}

.strength-bar {
  height: 4px;
  border-radius: 2px;
  transition: all 0.3s ease;
  width: 100%;
}

.strength-weak {
  background: linear-gradient(90deg, #E63946 0%, #E63946 33.33%, #f4f4f4 33.33%, #f4f4f4 100%);
}

.strength-medium {
  background: linear-gradient(90deg, #FFA84C 0%, #FFA84C 66.66%, #f4f4f4 66.66%, #f4f4f4 100%);
}

.strength-strong {
  background: #8ED76A;
}

.strength-text {
  font-size: 12px;
  margin-top: 4px;
  display: block;
}

.auth-email {
  height:auto;
}

.auth-email-div {
  height:48px;
}
</style>