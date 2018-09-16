describe('Fare Calculator', function() {
  
  beforeEach(function() {
    browser.get('http://localhost:54459/Home/Calculator');
	browser.pause();
  });

  it('should have a title', function() {
    expect(browser.getTitle()).toEqual('- Fare Calculator');
	browser.pause();
  });
  
  it('should add state NY, miles 2, minutes 5, date: 10/08/2010, time: 05:30:00 pm', function() {
	  
	browser.get('http://localhost:54459/Home/Calculator');
	browser.pause();
	var state = element(by.model('ride.state'));
	var miles = element(by.model('ride.miles'));
	var minutes = element(by.model('ride.minutes'));
	var date = element(by.model('ride.ridedate'));
	var time = element(by.model('ride.ridetime'));
	var submitClick = element(by.id('calc'));
	
    state.sendKeys('New York');
    miles.sendKeys(2);
	minutes.sendKeys(5);
	date.sendKeys('10-08-2010');
	time.sendKeys('0530PM');

	browser.sleep(2000);
    browser.wait(protractor.ExpectedConditions.visibilityOf(state), 20000); 
    submitClick.click();
	
	var cost = element(by.id('result'));

    expect(cost.getText()).toEqual('Cost: $9.75');

  });
});