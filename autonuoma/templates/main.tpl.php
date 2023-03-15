<!doctype html>
<html>
	<head>
        <meta name="robots" content="noindex">
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
    
        <title>Automobilių nuomos IS</title>
    
        <!-- Bootstrap CSS -->
        <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    
        <!-- Bootstrap Font Icon CSS -->
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css">
    
        <!-- Font Awesome Icon CSS -->
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
		
        <!-- Datepicker CSS-->
        <link rel="stylesheet" type="text/css" href="scripts/datetimepicker/jquery.datetimepicker.css"/ >

        <!-- Custom CSS-->
        <link rel="stylesheet" type="text/css" href="style/custom.css"/ >
		
        <!-- JQuery-->
        <script src="scripts/jquery-3.6.0.min.js"></script>

		<!-- Bootstrap core JS-->
        <script type="text/javascript" src="bootstrap/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
        
        <!-- Datepicker JS-->
        <script type="text/javascript" src="scripts/datetimepicker/jquery.datetimepicker.full.min.js"></script>

		<!-- Additional JS functions -->
        <script type="text/javascript" src="scripts/main.js"></script>
	</head>
	<body>
        <!-- Viršutinis meniu -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container">
                <a class="navbar-brand" href="index.php">
                    <i class="fa fa-database" style="font-size:24px"></i>    
                    Automobilių nuomos IS
                </a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
                        <li class="nav-item"><a class="nav-link <?php if($module == 'contract') { echo 'active'; } ?>" aria-current="page" href="index.php?module=contract&action=list">Sutartys</a></li>
                        <li class="nav-item"><a class="nav-link <?php if($module == 'service') { echo 'active'; } ?>" href="index.php?module=service&action=list">Paslaugos</a></li>
                        <li class="nav-item"><a class="nav-link <?php if($module == 'customer') { echo 'active'; } ?>" href="index.php?module=customer&action=list">Klientai</a></li>
                        <li class="nav-item"><a class="nav-link <?php if($module == 'employee') { echo 'active'; } ?>" href="index.php?module=employee&action=list">Darbuotojai</a></li>
                        <li class="nav-item"><a class="nav-link <?php if($module == 'car') { echo 'active'; } ?>" href="index.php?module=car&action=list">Automobiliai</a></li>
                        <li class="nav-item"><a class="nav-link <?php if($module == 'brand') { echo 'active'; } ?>" href="index.php?module=brand&action=list">Markės</a></li>
                        <li class="nav-item"><a class="nav-link <?php if($module == 'model') { echo 'active'; } ?>" href="index.php?module=model&action=list">Modeliai</a></li>
                        <li class="nav-item"><a class="nav-link <?php if($module == 'report') { echo 'active'; } ?>" href="index.php?module=report&action=list">Ataskaitos</a></li>
                    </ul>
                </div>
            </div>
        </nav>
        <!-- Puslapio turinys -->
        <div class="container" style="padding-bottom: 150px;">
            <div class="mt-5">
                <?php
                    // įtraukiame veiksmų failą
                    if(file_exists($actionFile)) {
                        include $actionFile;
                    } else {
						// rodome klaidą, jeigu nerastas kontrolerio failas
						throw new Exception("Nerastas kontrolerio failas '{$actionFile}'");	
					}
                ?>
            </div>
        </div>
        
    </body>
</html>