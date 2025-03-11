export default {
    extends: [
      'plugin:vue/vue3-recommended',
      'plugin:@typescript-eslint/recommended',
      'plugin:pug/recommended'
    ],
    parser: 'vue-eslint-parser',
    parserOptions: {
      parser: '@typescript-eslint/parser',
      sourceType: 'module'
    },
    rules: {
      '@typescript-eslint/no-unused-vars': 'off', // Disable TypeScript unused variable rule
      'vue/script-setup-uses-vars': 'error' // Ensure script setup variables are recognized
    }
  };