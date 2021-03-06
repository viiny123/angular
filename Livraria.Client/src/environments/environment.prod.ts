// `.env.ts` is generated by the `npm run env` command
import env from './.env';

export const environment = {
  production: true,
  version: env.npm_package_version,
  serverUrl: '',
  defaultLanguage: 'pt-BR',
  supportedLanguages: [
    'en-US',
    'pt-BR'
  ]
};
