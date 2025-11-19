/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}"
  ],
  theme: {
    extend: {
      fontFamily:{
        sans: ['"Libre Franklin"', 'ui-sans-serif', 'system-ui']
      }
    },
  },
  plugins: [],
}