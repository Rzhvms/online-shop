<template>
  <div class="page-bg">
    <div class="login-card">
      <h1 class="login-title">Регистрация</h1>

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
          <p v-if="errors.email" class="error-text">{{ errors.email }}</p>
        </div>

        <!-- Password -->
        <div class="field-wrap">
          <div :class="['field', errors.password ? 'field-error' : '']">
            <input
              v-model="password"
              :type="showPassword ? 'text' : 'password'"
              placeholder="Пароль"
              class="input"
              maxlength="30"
              @input="onPasswordInput"
            />
            <button type="button" class="show-btn" @click="showPassword = !showPassword">
              {{ showPassword ? '🙈' : '👁️' }}
            </button>
          </div>
          <p v-if="errors.password" class="error-text">{{ errors.password }}</p>

          <transition name="fade-slide">
            <div v-if="showPasswordStrength" class="password-strength-wrapper">
              <p class="contact-text" style="font-size: 16px; text-align: left; margin-bottom: 4px;">Сложность пароля:</p>
              <div class="password-strength">
                <div class="strength-bar" :style="{ width: strengthWidth, background: strengthColor }"></div>
                <span class="strength-text">{{ strengthText }}</span>
              </div>
            </div>
          </transition>
        </div>

        <p class="contact-text" style="margin-top: 8px; font-size: 12px;">
          Пароль должен содержать не менее 8 символов, включая <br>
          латинские буквы (a-z, A-Z), как минимум одну заглавную<br>
          букву и одну цифру
        </p>

        <button
          type="submit"
          class="submit-btn"
          :class="{ 'inactive-btn': !isFormValid }"
          :disabled="!isFormValid"
        >
          Далее
        </button>
      </form>

      <transition name="fade-slide-btn">
        <button v-if="showAltButton" class="create-btn" @click="handleLogin">
          У меня уже есть аккаунт
        </button>
      </transition>

      <p class="contact-text" style="margin-top: 16px;">
        По всем вопросам можете обращаться:<br>
        adminexample@gmail.com
      </p>
    </div>
  </div>
</template>

<script setup>
import { ref, computed, watch } from "vue";
import { useRouter } from "vue-router";

const router = useRouter();
const email = ref("");
const password = ref("");
const showPassword = ref(false);

const errors = ref({ email: null, password: null });
const passwordStrength = ref(0);
const showPasswordStrength = ref(false);

const isFormValid = computed(() => email.value.includes("@") && password.length >= 8);
const showAltButton = computed(() => !email.value && !password.value);

const handleSubmit = async () => {
  errors.value = { email: null, password: null };

  if (!email.value) errors.value.email = "Почта не указана";
  else if (!email.value.includes("@")) errors.value.email = "Неверный формат почты";

  if (!password.value) errors.value.password = "Пароль не указан";
  else if (password.value.length < 8) errors.value.password = "Пароль слишком короткий";

  if (errors.value.email || errors.value.password) return;

  router.push("/confirm-email");
};

const onPasswordInput = () => {
  checkPasswordStrength();
  if (password.value.length > 0) {
    setTimeout(() => showPasswordStrength.value = true, 50);
  } else {
    showPasswordStrength.value = false;
  }
};

const checkPasswordStrength = () => {
  const pass = password.value;
  let score = 0;
  if (pass.length >= 8) score += 1;
  if (/[a-z]/.test(pass) && /[A-Z]/.test(pass)) score += 1;
  if (/[0-9]/.test(pass)) score += 1;
  passwordStrength.value = score;
};

const strengthText = computed(() => {
  switch (passwordStrength.value) {
    case 1: return "Слабый";
    case 2: return "Средний";
    case 3: return "Сильный";
    default: return "Слабый";
  }
});

const strengthWidth = computed(() => {
  if (!password.value) return "10%";
  return `${passwordStrength.value * 30 + 10}%`;
});

const strengthColor = computed(() => {
  switch (passwordStrength.value) {
    case 1: return "#E63946";
    case 2: return "#FFA84C";
    case 3: return "#8ED76A";
    default: return "#E63946";
  }
});

const handleLogin = () => router.push("/login");
</script>

<style scoped>
@import './auth.css';

.fade-slide-enter-active, .fade-slide-leave-active {
  transition: all 0.3s ease;
}
.fade-slide-enter-from, .fade-slide-leave-to {
  opacity: 0;
  transform: translateY(-8px);
}
.fade-slide-enter-to, .fade-slide-leave-from {
  opacity: 1;
  transform: translateY(0);
}

.fade-slide-btn-enter-active, .fade-slide-btn-leave-active {
  transition: all 0.2s ease;
}
.fade-slide-btn-enter-from, .fade-slide-btn-leave-to {
  opacity: 0;
  transform: translateY(0);
}
.fade-slide-btn-enter-to, .fade-slide-btn-leave-from {
  opacity: 1;
  transform: translateY(0);
}

.password-strength {
  margin-top: 8px;
  margin-bottom: 8px;
  display: flex;
  flex-direction: column;
}

.strength-bar {
  height: 8px;
  border-radius: 4px;
  transition: width 0.3s ease, background 0.3s ease;
}

.strength-text {
  font-size: 12px;
  margin-top: 4px;
  display: block;
}

.submit-btn.inactive-btn {
  background-color: #FFA84C;
  color: white;
  cursor: not-allowed;
}

.submit-btn:enabled:hover {
  background-color: #f4f4f4;
  color: #ff7a00;
}
</style>