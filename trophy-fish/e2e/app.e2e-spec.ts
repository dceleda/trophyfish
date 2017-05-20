import { TrophyFishPage } from './app.po';

describe('trophy-fish App', () => {
  let page: TrophyFishPage;

  beforeEach(() => {
    page = new TrophyFishPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
