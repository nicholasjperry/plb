import { initializeApp } from 'firebase/app';
// import { getAnalytics } from 'firebase/analytics';

const firebaseConfig = {
  apiKey: 'AIzaSyDcjEdm15XSXwDbhO5O8av0Sywht9AM0Zo',
  authDomain: 'plb-ui.firebaseapp.com',
  projectId: 'plb-ui',
  storageBucket: 'plb-ui.firebasestorage.app',
  messagingSenderId: '559850756812',
  appId: '1:559850756812:web:a3ab4dc7975ec4e97ac069',
  measurementId: 'G-Y80QXMVF6M'
};

// Initialize Firebase
const firebaseApp = initializeApp(firebaseConfig);
// const analytics = getAnalytics(app);

export default firebaseApp;