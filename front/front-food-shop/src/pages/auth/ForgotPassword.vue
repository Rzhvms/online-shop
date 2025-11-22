<template>
  <div class="page-bg">
    <!-- Карточка -->
    <div class="login-card">
      <!-- Заголовок -->
      <h1 class="login-title">Восстановление пароля</h1>

      <!-- Инструкция -->
      <p class="contact-text" style="margin-bottom: 16px; text-align: center; font-size: 16px;">
        Введите вашу электронную почту, чтобы <br>
        получить код подтверждения и восстановить <br>
        доступ к аккаунту
      </p>

      <!-- Форма -->
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

        <!-- Submit -->
        <button
          type="submit"
          class="submit-btn"
          :class="{ 'hover-light': !isFormValid }"
          :disabled="!isFormValid"
        >
          Отправить код
        </button>
      </form>

      <!-- Отмена -->
      <button class="create-btn" @click="handleDecline">
        Отмена
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
import { useRouter } from "vue-router";
// import { sendVerificationEmail } from "@/services/api";

const router = useRouter();
const email = ref("");

const errors = ref({ email: null });

// Проверка валидности формы
const isFormValid = computed(() => {
  return email.value.length > 0 && email.value.includes("@");
});

const handleSubmit = async () => {
  errors.value.email = null;

  if (!email.value) {
    errors.value.email = "Почта не указана";
    return;
  } else if (!email.value.includes("@")) {
    errors.value.email = "Неверный формат почты";
    return;
  }

  try {
    // Пример API вызова
    // const response = await sendVerificationEmail(email.value);
    // if (!response.ok) {
    //   if (response.status === 404) errors.value.email = "Аккаунт с такой почтой не существует";
    //   else throw new Error("Не удалось отправить письмо");
    //   return;
    // }

    router.push("/confirm-email");
  } catch (error) {
    errors.value.email = error.message;
  }
};

const handleDecline = () => {
  router.push("/login");
};
</script>

<style scoped>
@import './auth.css';
</style>