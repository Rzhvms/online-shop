<template>
  <div class="auth-container">
    <!-- Карточка -->
    <div class="auth-card">
      <!-- Заголовок -->
      <h1 class="auth-title">Восстановление пароля</h1>

      <!-- Форма -->
      <form @submit.prevent="handleSubmit" class="auth-form">
        <p class="info-message">Введите вашу электронную почту, чтобы получить код подтверждения и восстановить доступ к аккаунту</p>  
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

        <!-- Submit -->
        <button
          type="submit"
          class="auth-button-submit">
          Отправить код
        </button>
      </form>

      <button
        type="submit"
        class="mt-4 text-sm text-orange-500 hover:underline rounded-xl"
        style="width: 362px; height: 48px; margin-top: 12px; background-color: F4F4F4;
        color: #555555; border-radius: 18px; border: none; font-size: 18px; font-weight: 600;"
        @click="handleDecline"
      >
        Отмена
      </button>

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
import { sendVerificationEmail } from "@/services/api";

const router = useRouter();
const email = ref("");
const password = ref("");
const remember = ref(false);
const showPassword = ref(false);

const errors = ref({ email: null, password: null });
const globalError = ref(null);

const passwordStrength = ref(0);

async function handleSubmit() {
  errors.value = { email: null, password: null };
  globalError.value = null;

  if (!email.value) errors.value.email = "Указана неправильная почта";
  if (!password.value) errors.value.password = "Пароль";

  if (email.value && !email.value.includes("@")) {
    errors.value.email = "Неверный формат почты";
  }

  if (!errors.value.email && !errors.value.password) {
    try {
      // const email_response = await sendVerificationEmail(email.value);
      // if (!email_response.ok) {
      //   throw new Error("Не удалось отправить письмо");
      // }
      // localStorage.setItem("email", email.value);
      router.push("/confirm-email");
    } catch (error) {
      console.log(error);
      globalError.value = error.message;
      return;
    }
  }
};

const handleDecline = () => {
  router.push("/login");
};
</script>

<style scoped>
@import './auth.css';
.email-placeholder::placeholder {
  transform: translateX(20px);
}
</style>