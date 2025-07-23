pipeline {
    agent any
    stages {
        stage("BlackDuckSecruityScan") {
            when {
                // Triggering Black Duck Security Scan on master branch or Pull Request
                anyOf {
                    branch 'master'
                    branch pattern: "PR-\\d+", comparator: "REGEXP"
                }
            }
            steps {
                script {
                    def status = security_scan product: 'coverity'
                        // Uncomment if below parameters are not set in global configuration                  
                        // coverity_url:'http://192.168.66.144:8080/',                           
                        // coverity_user: 'admin',
                        // coverity_passphrase: 'KfnCyber23*!'
        
                        // Pull Request Comments
                        //  coverity_prComment_enabled: true
                          
                        // Mark build status if issues found
                        //  mark_build_status: 'SUCCESS'
                
                    // Uncomment to add custom logic based on return status
                    // if (status == 8) { unstable 'policy violation' }
                    // else if (status != 0) { error 'plugin failure' }
                }
            }
        }
    }
}          
