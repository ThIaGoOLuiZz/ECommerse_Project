const base_url = 'https://localhost:7053/api';

export const API_ROUTES = {
    AUTH: {
        LOGIN: `${base_url}/Auth/authenticate`
    },
    USER: {
        POST_USER: `${base_url}/User`
    }
}