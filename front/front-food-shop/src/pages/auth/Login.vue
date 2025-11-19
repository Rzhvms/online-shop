<template>
  <div class="w-screen h-screen bg-[#F4F4F4] flex items-center justify-center">
    <!-- Карточка -->
    <div
      class="bg-white rounded-3xl shadow-lg flex flex-col items-center p-8"
      style="width: 410px; height: 508px; background-color: #FFFFFF; border-radius: 32px;"
    >
      <!-- Заголовок -->
      <h1 class="text-2xl font-semibold mb-6 text-center"
        style="
          margin-top: 40px;
          margin-bottom: 32px;
          color: #3C3C3C"
        >Вход
      </h1>

      <!-- Ошибка глобальная -->
      <div v-if="globalError" class="mb-4 text-center text-red-500 font-medium w-full">
        {{ globalError }}
      </div>

      <!-- Форма -->
      <form @submit.prevent="handleSubmit" class="flex flex-col gap-4 w-full items-center">

      <!-- Email -->
      <div class="relative w-[362px] h-[48px] mb-[12px]">
        <div
          class="flex items-center w-full h-full border rounded-xl px-4 py-2 focus-within:ring-2 focus-within:ring-orange-400"
          style="border:none; background-color: #F4F4F4; border-radius: 18px;"
          :class="errors.email ? 'border-red-500' : 'border-gray-300'"
        >
          <input
            v-model="email"
            type="email"
            placeholder="Почта"
            class="flex-1 bg-transparent outline-none text-black"
            style="border: none; margin-left: 20px; font-size: 16px;"
          />
        </div>
        <p v-if="errors.email" class="text-red-500 text-sm mt-1">{{ errors.email }}</p>
      </div>

        <!-- Password -->
        <div class="relative w-[362px] h-[48px]">
          <div
            class="flex items-center w-full h-full border rounded-xl px-4 py-2 focus-within:ring-2 focus-within:ring-orange-400"
            style="border:none; background-color: #F4F4F4; border-radius: 18px;"
            :class="errors.password ? 'border-red-500' : 'border-gray-300'"
          >
            <input
              v-model="password"
              :type="showPassword ? 'text' : 'password'"
              placeholder="Пароль"
              class="flex-1 bg-transparent outline-none text-black"
              style="border: none; margin-left: 20px; font-size: 16px;"
            />

            <!-- SHOW / HIDE внутри поля -->
            <button
              type="button"
              class="ml-2 w-6 h-6 flex items-center justify-center text-gray-500 hover:text-black"
              style="background: none; border: none; padding: 0; padding-right: 15px;"
              @click="showPassword = !showPassword"
            >
              {{ showPassword ? '🙈' : '👁️' }}
            </button>
          </div>
          <p v-if="errors.password" class="text-red-500 text-sm mt-1">{{ errors.password }}</p>
        </div>

        <!-- Remember + Forgot -->
        <div class="flex items-center justify-between w-full mb-2 select-none"
          style="margin-top: 8px; width: 362px;"
        >
          <label class="flex items-center space-x-2 cursor-pointer">
            <input type="checkbox" 
                   v-model="remember"
                   class="w-4 h-4 rounded-sm border-gray-400 border checked:bg-orange-500 checked:border-orange-500 cursor-pointer"
            />
            <span class="text-sm"
              style="color: #3C3C3C;"
              >Запомнить меня
            </span>
          </label>
          <button type="button" 
                  class="text-sm text-orange-500 hover:underline"
                  style="
                    border: none;
                    background: white;
                    color: #ff7a00;
                    font-size: 16px;"
                  >Забыли пароль?
          </button>
        </div>

        <!-- Submit -->
        <button
          type="submit"
          class="bg-orange-500 text-white rounded-xl transition hover:bg-orange-600 font-medium"
          style="width: 362px; height: 48px; margin-top: 32px; background-color: #FF7A00;
          color: white; border-radius: 18px; border: none; font-size: 18px; font-weight: 600;"
        >
          Войти
        </button>
      </form>

      <!-- Create account -->
      <button
        type="submit"
        class="mt-4 text-sm text-orange-500 hover:underline rounded-xl"
        style="width: 362px; height: 48px; margin-top: 12px; background-color: F4F4F4;
        color: #555555; border-radius: 18px; border: none; font-size: 18px; font-weight: 600;"
      >
        Создать аккаунт
      </button>

      <p class="text-xs text-gray-400 mt-2 text-center"
        style="
          font-size: 12px;
          color: #7A7A7A;
        ">
        По всем вопросам можете обращаться:<br>
        adminexample@gmail.com
      </p>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";

const email = ref("");
const password = ref("");
const remember = ref(false);
const showPassword = ref(false);

const errors = ref({ email: null, password: null });
const globalError = ref(null);

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
</script>

<style scoped>
.email-placeholder::placeholder {
  transform: translateX(20px);
}
</style>