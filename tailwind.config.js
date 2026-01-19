export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {},
  },
  plugins: [],

theme: {
  extend: {
    animation: {
      "spin-slow": "spin 6s linear infinite",
      fade: "fade 2s ease-in-out infinite",
    },
    keyframes: {
      fade: {
        "0%, 100%": { opacity: 0.4 },
        "50%": { opacity: 1 },
      },
    },
  },
},
};