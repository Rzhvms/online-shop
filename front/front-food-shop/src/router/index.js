import { createRouter, createWebHistory } from 'vue-router'

// Auth pages
import Login from '../pages/auth/Login.vue'
import Register from '../pages/auth/Register.vue'
import ConfirmEmail from '../pages/auth/ConfirmEmail.vue'
import FinishRegistration from '../pages/auth/FinishRegistration.vue'
import ForgotPassword from '../pages/auth/ForgotPassword.vue'
import ForgotPasswordOptions from '../pages/auth/ForgotPasswordOptions.vue'

// Home
import Home from '../pages/home/Index.vue'

// Catalog
import CatalogIndex from '../pages/catalog/Index.vue'
import Category from '../pages/catalog/Category.vue'
import Subcategory from '../pages/catalog/Subcategory.vue'
import ProductCard from '../pages/catalog/ProductCard.vue'

// Cart
import Cart from '../pages/cart/Index.vue'

// Checkout
import CheckoutAddress from '../pages/checkout/Address.vue'
import CheckoutConfirm from '../pages/checkout/Confirm.vue'
import CheckoutPayment from '../pages/checkout/Payment.vue'

// Profile
import ProfileIndex from '../pages/profile/Index.vue'
import ProfileMain from '../pages/profile/Main.vue'
import ProfileSettings from '../pages/profile/Settings.vue'

// Admin
import AdminIndex from '../pages/admin/Index.vue'

const routes = [
  { path: '/', component: Home },

  // Auth
  { path: '/login', component: Login },
  { path: '/register', component: Register },
  { path: '/confirm-email', component: ConfirmEmail },
  { path: '/finish-registration', component: FinishRegistration },
  { path: '/forgot-password', component: ForgotPassword },
  { path: '/forgot-password-options', component: ForgotPasswordOptions },

  // Catalog
  { path: '/catalog', component: CatalogIndex },
  { path: '/catalog/category', component: Category },
  { path: '/catalog/subcategory', component: Subcategory },
  { path: '/catalog/product', component: ProductCard },

  // Cart
  { path: '/cart', component: Cart },

  // Checkout
  { path: '/checkout/address', component: CheckoutAddress },
  { path: '/checkout/confirm', component: CheckoutConfirm },
  { path: '/checkout/payment', component: CheckoutPayment },

  // Profile
  { path: '/profile', component: ProfileIndex },
  { path: '/profile/main', component: ProfileMain },
  { path: '/profile/settings', component: ProfileSettings },

  // Admin
  { path: '/admin', component: AdminIndex },
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router