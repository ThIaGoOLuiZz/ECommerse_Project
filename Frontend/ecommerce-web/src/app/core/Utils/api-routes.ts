const base_url = 'https://localhost:7053/api';

export const API_ROUTES = {
    AUTH: {
        LOGIN: `${base_url}/Auth/authenticate`
    },
    USER: {
        CREATE: `${base_url}/User`
    }
}